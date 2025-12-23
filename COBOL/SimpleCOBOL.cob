       IDENTIFICATION DIVISION.
       PROGRAM-ID. SAMPLE01.

       DATA DIVISION.
       WORKING-STORAGE SECTION.
       01 WS-NAME        PIC X(20) VALUE "Nick".
       01 WS-TOTAL       PIC 9(5)  VALUE 0.

       PROCEDURE DIVISION.
       MAIN-PARA.

           PERFORM INIT-PARA
           PERFORM PROCESS-PARA
           PERFORM DISPLAY-PARA

           STOP RUN.

       INIT-PARA.
           MOVE 100 TO WS-TOTAL.

       PROCESS-PARA.
           ADD 25 TO WS-TOTAL.

       DISPLAY-PARA.
           DISPLAY "Name   : " WS-NAME
           DISPLAY "Total  : " WS-TOTAL.
