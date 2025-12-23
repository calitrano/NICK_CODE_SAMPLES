       IDENTIFICATION DIVISION.
       PROGRAM-ID. HELLOCOBOL.

       ENVIRONMENT DIVISION.

       DATA DIVISION.
       WORKING-STORAGE SECTION.
       01 WS-NAME        PIC X(20) VALUE "Nick".
       01 WS-MESSAGE     PIC X(50).

       PROCEDURE DIVISION.
       MAIN-PARA.

           MOVE "Hello from COBOL, " TO WS-MESSAGE
           STRING WS-MESSAGE
                  WS-NAME
                  DELIMITED BY SIZE
                  INTO WS-MESSAGE
           END-STRING

           DISPLAY WS-MESSAGE

           STOP RUN.
