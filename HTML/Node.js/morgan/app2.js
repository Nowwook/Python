const express = require('express')
const fs = require('fs')
const morgan = require('morgan')
const path = require('path')

const app = express()

const accessLogStream = fs.createWriteStream(
    path.join(__dirname, 'access.log'),{
        flags: 'a'})

app.use(morgan('combined', {stream: accessLogStream}))

app.get('/', function(req, res){-
    res.send('Main Page')
})

var server = app.listen(80, function(){
    console.log("서버 시작 ")
})
