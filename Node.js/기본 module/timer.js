const fs = require('fs')

const interval = setInterval(() => {
    let time = new Date()
    fs.appendFileSync("currentTime.txt",time.toLocaleTimeString(),{encoding: 'utf-8'})
    console.log(time.toLocaleTimeString())
},1000)

setTimeout(() => {
    clearInterval(interval)
},6000)

