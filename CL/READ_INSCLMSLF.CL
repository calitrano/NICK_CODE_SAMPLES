Loop through INSCLMSLF from CL (DCLF / RCVF)
=================================================

CL's native record-level read is DCLF + RCVF (see CL/SIMPLE_PROGRAM.CL
for the concept). This loops through the whole logical file INSCLMSLF
(record format INSCLMSREC, keyed DESCEND on CLMNO, ST = 'NY' omitted -
see DDS/LOGICAL_FILE.DDS). Because RCVF is native record-level access,
not SQL, it walks INSCLMSLF's access path directly - claims come back
highest CLMNO first, guaranteed, the same way RPG's READ does in
RPG/READ_INSCLMSLF.RPG.

             PGM

             DCLF       FILE(DENORAN/INSCLMSLF)

             DCL        VAR(&CNT) TYPE(*DEC) LEN(5 0) VALUE(0)
             DCL        VAR(&MSG) TYPE(*CHAR) LEN(80)

             DOWHILE    COND('1')

                RCVF
                MONMSG     MSGID(CPF0864) EXEC(LEAVE)   /* end of file */

                CHGVAR     VAR(&CNT) VALUE(&CNT + 1)
                CHGVAR     VAR(&MSG) VALUE('Claim ' *CAT %CHAR(&CLMNO) *CAT +
                                            ' - ' *CAT &CUSTOMER *CAT +
                                            ' (' *CAT &ST *CAT ')')
                SNDPGMMSG  MSG(&MSG)

             ENDDO

             CHGVAR     VAR(&MSG) VALUE(%CHAR(&CNT) *CAT ' claim(s) read')
             SNDPGMMSG  MSG(&MSG)

             ENDPGM

Meaning:
	• DCLF FILE(DENORAN/INSCLMSLF) - declares the logical file; CL
	  auto-creates one CL variable per field in the record format
	  (&CLMNO, &CUSTOMER, &STREET, &CITY, &ST, &NOTES) - no manual
	  DCL needed for them, the same "no D-specs" convenience RPG gets
	  from an externally described "E" F-spec
	• DOWHILE COND('1') - an intentional infinite loop; the only way
	  out is the MONMSG below hitting LEAVE, since CL has no built-in
	  %EOF() the way RPG/COBOL do
	• RCVF - reads the NEXT record from INSCLMSLF, in access-path
	  order (CLMNO DESCEND); populates &CLMNO/&CUSTOMER/etc. with
	  that record's values
	• MONMSG MSGID(CPF0864) EXEC(LEAVE) - CPF0864 is "end of file
	  detected" on a RCVF/READ. Catching it and running LEAVE is CL's
	  version of "DOW NOT %EOF()" - without this MONMSG, hitting end
	  of file would abend the program instead of ending the loop
	  cleanly
	• %CHAR(&CLMNO) - converts the numeric &CLMNO to character so it
	  can be concatenated with *CAT into the message text; CL (unlike
	  RPG's DSPLY) won't implicitly convert numeric to character in a
	  string expression
	• &CNT counts records actually read, then gets reported once the
	  loop ends - a simple way to confirm the ST = 'NY' omit and the
	  DESCEND key are both doing what you expect without eyeballing
	  every line


What you CANNOT do here that RPG/COBOL can:
	• No CHAIN/SETLL-style jump to a specific CLMNO - RCVF only ever
	  moves forward, one record at a time, from wherever the access
	  path currently is
	• No WRITE/UPDATE/DELETE against INSCLMSLF from CL - RCVF is
	  read-only
	• Only one DCLF'd database file active this way per program in
	  the simple form shown here


Quick reference
-------------------
	• DCLF     -> declares a file and auto-declares one CL variable
	  per field in its record format
	• RCVF     -> reads the next record (native access-path order)
	• CPF0864  -> "end of file" message raised by RCVF at end of file
	• LEAVE    -> exits the current DOWHILE/DOUNTIL loop immediately
	• %CHAR()  -> converts a numeric/date CL variable to character
