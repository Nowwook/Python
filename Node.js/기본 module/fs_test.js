const fs = require('fs')

fs.readFile('./abc.txt','utf-8',function(err,data){
    if(err){
        throw err
    }
    console.log(data)
})