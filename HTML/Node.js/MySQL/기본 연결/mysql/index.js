// 모듈 설정
const { rejects } = require('assert')
const mysql = require('mysql')
const { resolve } = require('path')
const sql = require('./sql')

// DBMS(MySQL) 연결설정
const pool = mysql.createPool({
    connectionLimit: 10,
    host: '127.0.0.1',
    port: '3306',
    user: 'root',
    password: 'iot123',
    database: 'dev'
})

// 쿼리문을 실행, 결과 반환
const query = async(alias,values) => {
    return new Promise( (resolve,reject) => pool.query(sql[alias],values,(error,results) => {
        if(error){
            console.log(error)
            reject({
                error
            })
        }
        else{
            resolve(results)
        }
    }))
}

module.exports = {
    query
}
