/*
express.Router 는 라우터 처리를 여러개의 파일로 분리하여 용도에 맞게 사용하게 구현
*/

const express =require('express')
const customerRoute =require('./routes/customers')
const productRoute =require('./routes/product')
const app = express()

// 7.4 Express 정적 파일 제공
app.use('/static',express.static('public'))

app.use(express.json({
    limit: '50mb'
}))

// root
app.get('/',function(req,res) {
    res.send('main page')
})

app.listen(3000, () => {
    console.log("서버 스타트 .. 포트 3000..")
})

app.use('/customer',customerRoute)
app.use('/product',productRoute)
