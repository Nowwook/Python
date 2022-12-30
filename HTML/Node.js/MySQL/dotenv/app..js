const express =require('express')
// 순서 주의
require('dotenv').config({path: 'mysql/.env'});
const mysql = require('./mysql')

const app = express()

app.listen(3000, () => {
    console.log("server started port 3000...")
})

app.get('/',function(req,res) {
    res.send('main page')
})
app.get('/api/customers',async(req,res) => {
    const customers = await mysql.query('customerList')
    console.log(customers)
    res.send(customers)
})
