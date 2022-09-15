// 모듈 ejs, express

const express = require('express')
const ejs = require('ejs')

const app = express()

app.set('view engine', 'ejs')
app.use(express.json()) 
app.use(express.urlencoded({extended: true}));

app.use(express.json({
    limit: '50mb'
}))

app.listen(3000, () => {
    console.log("Server Started port 3000...")
})

app.get('/', function(req,res){
    res.render('math')
})

app.post('/math/result1', async(req, res) => {
    res.send(`${req.body.t1 * req.body.t2}`)
})

app.get('/view', function(req,res){
    res.render('view')
})

app.post('/result', function(req,res){
    const obj = [
        {
            result: `${parseInt(req.body.t1) + parseInt(req.body.t2)}`
        },
        {
            result: `${req.body.t3 - req.body.t4}`
        },
        {
            result: `${req.body.t5 * req.body.t6}`
        },
        {
            result: `${req.body.t7 / req.body.t8}`
        }
    ]
    res.render('result', {data: obj});
})
