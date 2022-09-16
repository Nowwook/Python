const express = require('express')
const morgan = require('morgan')

const app = express()

app.use(morgan('combined'))

app.get('/', function(req, res){-
    res.send('Main Page')
})

var server = app.listen(80, function(){
    console.log("서버 시작 ")
})
