const express = require('express')
const app = express()

app.get('/',function(req,res){
    res.send('root')
})

app.get('/example', function (req, res, next)
{
    console.log('첫 번째 콜백 함수')
    next()
}, 
function (req, res)
{
    console.log('두 번째 콜백 함수')
    res.send('두 번째 콜백 함수')
})

const ex0 = function(req,res,next){
    console.log('첫 번째 콜백함수 exmaple2')
    next()
}
const ex1 = function(req,res){
    console.log('두 번째 콜백 함수 example2')
    res.send('두 번째 콜백 함수 example2')
}

app.get('/example2',[ex0,ex1])
app.listen(3000, ()=>{
    console.log('서버 시작 포트 3000')
})

