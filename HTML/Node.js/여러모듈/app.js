/*
ejs
express
morgan
os
systeminformation
*/

const express = require('express')
const fs = require('fs')
const morgan = require('morgan')
const ejs = require('ejs')
const path = require('path')
const os = require('os')
const si = require('systeminformation')

const app = express()

const accessLogStream = fs.createWriteStream(
  path.join(__dirname, 'time.txt'),{flags: 'a'})

app.set('view engine', 'ejs')

// 접속시 현재시간 txt에 5번 입력
for(var i=0; i < 5; i++)
  {
    app.use(morgan(':date',{stream: accessLogStream}))
  }

// // time.txt > info.txt 변경
// fs.rename('time.txt' , 'info.txt',function(err) {
//     if ( err ) console.log(err);
// })

// os 정보 입력
const text = os.hostname() +'\n\n' + os.totalmem() +'\n\n' + os.freemem()+'\n\n' + os.cpus
fs.writeFile('info.txt', text,'utf-8',(err) => {
  if (err) console.error(err)
})

// systeminformation 이용 CPU 정보 출력
si.cpu(function(data){
  console.log(data.cores)
  console.log(data.voltage)
  console.log(data.brand)
})

app.get('/', function(req, res){
    res.send('txt에 시간 저장')
})

// time.txt 파일 중 가장 마지막 5줄을 웹페이지에 출력
app.get('/2',function(req,res){
  var array = fs.readFileSync('time.txt').toString().split("\n")
  var arr = ""
  for(var i=2; i < 7; i++)
  {
    arr = arr +'\n'+ array[array.length - i]
  }
  console.log(arr)

  const result = [
    {
      result: arr
    }
  ]
  res.render('result', {data: result})
})

var server = app.listen(80, function(){
    console.log("서버 시작 ")
})
