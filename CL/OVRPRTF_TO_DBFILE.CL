Redirect a printed report into a database file (OVRPRTF + CPYSPLF)
=======================================================================

Some report, somewhere, still writes to a PRINTER file (DDS printer
file or an RPG program with a PRTF). This CL program runs that report
without letting it hit a real printer, holds the resulting spooled
file, then copies its lines into a database file instead.

             PGM

             DCL        VAR(&SPLNAME) TYPE(*CHAR) LEN(10) VALUE('CLAIMS')

             /* 1. Redirect the printer file's output to a HELD spool  */
             /*    entry instead of letting it go straight to a device */
             OVRPRTF    FILE(QPRINT) HOLD(*YES) SPLFNAME(&SPLNAME)

             /* 2. Run whatever program actually produces the report - */
             /*    it still thinks it's printing normally               */
             CALL       PGM(CLAIMRPT)

             /* 3. Copy that spooled file's lines into a database file */
             CPYSPLF    FILE(QPRINT) TOFILE(DENORAN/CLAIMSOUT) +
                          JOB(*) SPLNBR(*LAST) MBROPT(*REPLACE)

             /* 4. Remove the override so later runs aren't affected   */
             DLTOVR     FILE(QPRINT)

             ENDPGM

Meaning:
	• OVRPRTF FILE(QPRINT) HOLD(*YES) - CLAIMRPT opens QPRINT (a
	  printer file) same as always; the override intercepts that open
	  and holds the spooled output on the output queue instead of
	  sending it to an actual printer. SPLFNAME gives the held spool
	  entry a predictable name to look up afterward
	• CALL PGM(CLAIMRPT) - the report program is completely unaware
	  anything was overridden; this is the whole point of OVRPRTF -
	  redirect behavior without touching the program's source
	• CPYSPLF FILE(QPRINT) TOFILE(DENORAN/CLAIMSOUT) - copies the
	  held spooled file's content into a database file, one record
	  per printed line. If CLAIMSOUT doesn't already exist, CPYSPLF
	  creates it using a system model format: mostly a single
	  fixed-length character field (SPLDTA-style) holding each
	  line's text, plus a leading print-control character by default
	  (CTLCHAR(*FCFC)) - it's raw printed text, not typed columns
	• SPLNBR(*LAST) - grabs the most recent spooled file with that
	  name/job, in case more than one exists; MBROPT(*REPLACE) blows
	  away any prior contents in CLAIMSOUT rather than appending
	• DLTOVR FILE(QPRINT) - removes the override; skipping this step
	  is a common bug - the NEXT job/session that also opens QPRINT
	  would silently inherit your override otherwise


When NOT to bother with print/spool at all
------------------------------------------------
If you're generating the data fresh rather than capturing an existing
printed report, skip OVRPRTF/CPYSPLF entirely - it gives you one flat
text field per line, which usually means re-parsing column positions
back out again. Cleaner options:
	• Query/400: RUNQRY QRYFILE(DENORAN/INSCLMSLF) OUTPUT(*OUTFILE) +
	  OUTFILE(DENORAN/CLAIMSOUT) OUTMBR(*FIRST *REPLACE) - writes one
	  real, typed field per selected column, no spool involved
	• SQL: INSERT INTO DENORAN.CLAIMSOUT SELECT * FROM DENORAN.INSCLMSLF
	  - or CREATE TABLE ... AS (SELECT ...) - no print/spool step at all


Quick reference
-------------------
	• OVRPRTF   -> redirects a printer file's output (device, hold
	  status, spool file name) without changing the calling program
	• HOLD(*YES) -> keeps the spooled file on the output queue instead
	  of sending it to a device
	• CPYSPLF   -> copies an existing spooled file's lines into a
	  database file, one record per printed line
	• SPLNBR    -> which spooled file to copy when more than one
	  exists with the same name (*LAST, *ONLY, or a specific number)
	• DLTOVR    -> removes a file override - always clean up after
	  yourself so later jobs aren't affected
	• OUTPUT(*OUTFILE) on RUNQRY, or plain SQL INSERT/CREATE TABLE AS
	  SELECT -> the better route when there's no existing print
	  report to capture, since both write real typed columns directly
