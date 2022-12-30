var express = require('express');  
var app=express();  

app.set('view engine','ejs')    // html template을 ejs로 사용
app.set('views','./views')        // views폴더를 ./views로 지정

app.get('/',(req, res) => {  
    res.send('main page')
})

app.get('/join',(req, res) => {  
    // 코딩 ~~
    res.render('join_form')
})

var server = app.listen(5000, function () {  
    var host = server.address().address  
    var port = server.address().port  
    console.log("서버 시작 http://%s:%s", host, port)  
  }) 
