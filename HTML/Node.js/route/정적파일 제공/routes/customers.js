const express =require('express')
const router = express.Router()

// 고객정보 조회를 위한 라우트
router.get('/',function(req,res) {
    res.send('customer 라우터 루트')
})

// 고객정보 추가를 위한 라우트
router.post('/insert',function(req,res) {
    res.send('/customer/insert 루트')
})

// router.put
// router.delete

module.exports =router
