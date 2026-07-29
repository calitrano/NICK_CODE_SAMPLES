CL (Control Language) - simple program examples
=================================================

CL is IBM i's job-control / system programming language. Unlike DDS
(which only describes data) CL is a real procedural language - it has
variables, IF/DOWHILE, error handling - but its job is to drive the
*system*: call programs, work with objects, submit jobs, and glue
things together, rather than process business data the way RPG does.

A CL program is a source member that gets compiled into a *program
object (Program: *PGM)** with CRTCLPGM/CRTBNDCL.


Hello World
---------------

             PGM

             SNDPGMMSG  MSG('Hello from CL')

             ENDPGM

Meaning:
	• PGM   - marks the start of the program (like RPG's implicit
	  cycle start, or "main")
	• SNDPGMMSG - sends a message; here it just prints text to the
	  job log / caller, the CL equivalent of RPG's DSPLY
	• ENDPGM - marks the end of the program


Parameters and variables (DCL)
-----------------------------------

             PGM        PARM(&CUSNO &CUSNAME)

             DCL        VAR(&CUSNO)   TYPE(*DEC) LEN(6 0)
             DCL        VAR(&CUSNAME) TYPE(*CHAR) LEN(30)
             DCL        VAR(&MSG)     TYPE(*CHAR) LEN(50)

             CHGVAR     VAR(&MSG) VALUE('Customer ' *CAT &CUSNAME)
             SNDPGMMSG  MSG(&MSG)

             ENDPGM

Meaning:
	• PARM(&CUSNO &CUSNAME) on the PGM line declares the parameters
	  this program is called with, in order - like an RPG program's
	  *ENTRY PLIST, or a function signature
	• DCL declares every variable up front: VAR is the name (CL
	  variables always start with &), TYPE/LEN give the data type and
	  length (*DEC = packed/decimal, *CHAR = character, *LGL = logical)
	• CHGVAR assigns a value; *CAT concatenates strings
	• Every variable used in a CL program - including the parameters -
	  must be declared with DCL; there's no implicit typing


IF / ELSE
--------------

             PGM        PARM(&STATUS)

             DCL        VAR(&STATUS) TYPE(*CHAR) LEN(1)

             IF         COND(&STATUS *EQ 'A') THEN(DO)
                SNDPGMMSG  MSG('Customer is active')
             ENDDO
             ELSE       CMD(DO)
                SNDPGMMSG  MSG('Customer is not active')
             ENDDO

             ENDPGM

Meaning:
	• IF ... THEN(DO) / ENDDO brackets a multi-command block, the CL
	  equivalent of RPG's IF/ENDIF
	• *EQ, *NE, *GT, *LT, *GE, *LE are the comparison operators
	  (CL spells them out instead of using symbols)
	• ELSE CMD(DO) / ENDDO is the else branch


DOWHILE loop
----------------

             PGM

             DCL        VAR(&I) TYPE(*DEC) LEN(3 0) VALUE(1)

             DOWHILE    COND(&I *LE 5)
                SNDPGMMSG  MSG('Loop count:' *CAT &I)
                CHGVAR     VAR(&I) VALUE(&I + 1)
             ENDDO

             ENDPGM

Meaning:
	• DOWHILE ... ENDDO loops while the condition is true, like RPG's
	  DOW; CL also has DOUNTIL for a post-tested loop


MONMSG - handling errors
-----------------------------

             PGM

             DCL        VAR(&CUSNO) TYPE(*DEC) LEN(6 0)

             CALL       PGM(GETCUST) PARM(&CUSNO)
             MONMSG     MSGID(CPF0000) EXEC(DO)
                SNDPGMMSG  MSG('GETCUST failed - continuing anyway')
             ENDDO

             ENDPGM

Meaning:
	• CALL invokes another *PGM object and passes parameters - the CL
	  equivalent of RPG's CALLP/CALL
	• MONMSG "monitors" for an escape/error message class right after
	  the command it follows; CPF0000 is a wildcard that catches any
	  IBM-supplied error message (CPFxxxx range)
	• If GETCUST fails, control passes into the MONMSG's EXEC(DO) block
	  instead of the program abending - CL's version of exception
	  handling; without a MONMSG, an unhandled error message ends
	  the program


Quick reference
-------------------
	• PGM / ENDPGM   -> start / end of the program
	• PARM           -> parameters the program is called with
	• DCL            -> declares a variable (name, type, length)
	• CHGVAR         -> assigns a value to a variable
	• SNDPGMMSG      -> sends a message (display text / signal caller)
	• IF / ELSE      -> conditional logic (THEN(DO)/ELSE CMD(DO)/ENDDO)
	• DOWHILE/DOUNTIL -> pre-tested / post-tested loops
	• CALL           -> invokes another program, passing parameters
	• MONMSG         -> catches an error/escape message and reacts to it
	• *EQ *NE *GT *LT *GE *LE -> comparison operators
