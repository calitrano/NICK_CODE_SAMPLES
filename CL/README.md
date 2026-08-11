IBM i Control Language (CL) samples.

- `InlineSQL.CLLE` - runs SQL statements directly from a CL program using
  the `RUNSQL` command (insert, update, and a `SELECT ... INTO` to read a
  value back into CL variables). Unlike RPG or COBOL, CL does not need an
  embedded SQL precompile step to run SQL inline. Requires IBM i 7.3 TR6 /
  7.4 or later (`RUNSQL` doesn't exist on earlier releases - use
  `RUNSQLSTM` against a source member instead). Written by hand and not
  compiled against a live IBM i host, so review it before running in a
  real environment.
