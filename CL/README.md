# CL (IBM i / AS400) Samples

This folder contains Control Language (CL) program examples for IBM i.

## CPYPFLOOP.CLLE

Copies every physical file (*PF) found in a source library to a target
library, one file at a time, in a loop.

- Takes two parameters: `&FROMLIB` (source library) and `&TOLIB` (target
  library).
- Uses `DSPOBJD OUTPUT(*OUTFILE)` to build a work file listing every object
  in `&FROMLIB`, so the list of files to copy is discovered at run time
  instead of being hard coded.
- Loops through that work file with `RCVF`, skips any object whose
  attribute is not `PF` (logical files, etc.), and issues a `CPYF` for
  each physical file via `QCMDEXC`.
- Tracks a copied count and an error count with `MONMSG`, and sends a
  completion message summarizing the results when the loop ends.

Example call:

```
CALL PGM(CPYPFLOOP) PARM('MYLIBSRC' 'MYLIBTGT')
```
