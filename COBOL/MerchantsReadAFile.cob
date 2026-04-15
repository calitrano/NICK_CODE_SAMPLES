       IDENTIFICATION DIVISION.
       PROGRAM-ID. BATCH1.
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
123456*
      *     SELECT INFILE ASSIGN TO "input.txt"
      *     SELECT INFILE ASSIGN TO "C:\\Users\\CALIT\\COBOL_SOURCE\\
      *      input.txt".
      * SELECT INFILE ASSIGN TO "E:\\COMPUTER_STUFF\\COBOL\\bin\\"
      *    "input.txt"
      *    ORGANIZATION IS LINE SEQUENTIAL.
      *SELECT OUTFILE ASSIGN TO "output.txt".
       SELECT INFILE ASSIGN TO "E:\COMPUTER_STUFF\COBOL\bin\input.txt".
      * SELECT INFILE ASSIGN TO "E:\COBOL\bi"
      *-    "n\input.txt".
      *SELECT INFILE ASSIGN TO 'E:\COBOL\bin\input.txt'.     
           
       SELECT OUTFILE ASSIGN TO "output.txt".
       DATA DIVISION.
       FILE SECTION.

       FD  INFILE.
       01  IN-REC.
           05 CUST-ID     PIC 9(5).
           05 NAME        PIC X(15).
           05 BALANCE     PIC 9(6).

       FD  OUTFILE.
       01  OUT-REC        PIC X(30).

       WORKING-STORAGE SECTION.
       01  WS-TOTAL       PIC 9(7) VALUE 0.
       01  EOF-FLAG       PIC X VALUE 'N'.

       PROCEDURE DIVISION.

       OPEN INPUT INFILE
            OUTPUT OUTFILE

       PERFORM UNTIL EOF-FLAG = 'Y'

           READ INFILE

               AT END
                   MOVE 'Y' TO EOF-FLAG
               NOT AT END
                DISPLAY IN-REC
                DISPLAY "123456789012345678901234567890"
                DISPLAY IN-REC
                   IF BALANCE IS NUMERIC
                       ADD BALANCE TO WS-TOTAL
                       MOVE IN-REC TO OUT-REC
                       INSPECT OUT-REC REPLACING ALL " " BY "."
                       DISPLAY OUT-REC
                       WRITE OUT-REC
                   ELSE
                       DISPLAY "BAD RECORD: " IN-REC
                   END-IF

           END-READ

       END-PERFORM

       DISPLAY "TOTAL: " WS-TOTAL

       CLOSE INFILE OUTFILE

       STOP RUN.
