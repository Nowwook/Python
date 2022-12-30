const express = require('express')
const app = express()

app.get('/',function(req,res){
    res.send('메인 화면')
})

app.route('/product')
    .get(function(req,res){
        // get 코딩
        res.send('get 코딩')
    })
    .post(function(req,res){
        // post 코딩
        res.send('post 코딩')
    })
    .put(function(req,res){
        //put 코딩
        res.send('put 코딩')
    })
    .delete(function(req,res){
        //delete 코딩
        res.send('delete 코딩')
    })
app.listen(3000, ()=>{
    console.log('서버 시작 포트 3000')
})

//PUT method와 DELETE method는 HTML이 지원하지 않음
//사용하려면 method-override 패키지 사용
//const methodOverride = require('method-override')
//app.use(methodOverride())
