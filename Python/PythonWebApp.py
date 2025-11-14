### installing flask to build a website... 
#### first thing i did was go to command line below and say pip install flask and it brought in libraries then here i go
## 
from flask import Flask 
app = Flask(__name__)
@app.route("/")
def index():
    return "Welcome to the index page. Nick"

@app.route("/hi/")
def who():
        return "Who are you?"

## do not indent !!!

@app.route("hi/<username>")
def greet(username):
     return f"Hi there, {username}!"

## to run this type at the cmd prompt below py -m flask run