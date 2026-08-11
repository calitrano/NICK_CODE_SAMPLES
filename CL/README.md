IBM i Control Language (CL) samples.

- `InlineSQL.CLLE` - runs SQL statements directly from a CL program using
  the `RUNSQL` command (insert and update, built from CL variables).
  Unlike RPG or COBOL, CL does not need an embedded SQL precompile step
  to run SQL inline - but CL also has no `:hostvar` binding syntax, so
  values are substituted by building the SQL text yourself with
  `CHGVAR`/concatenation and passing the resolved string to `RUNSQL`.
  Requires IBM i 7.3 TR6 / 7.4 or later (`RUNSQL` doesn't exist on
  earlier releases - use `RUNSQLSTM` against a source member instead).
  Written by hand and not compiled against a live IBM i host, so review
  it before running in a real environment.
