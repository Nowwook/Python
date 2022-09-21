const fs = require('fs')
const parse = require('csv-parse')

const csv = fs.readFileSync('./data.csv')
const records = parse(csv.toString('utf-8'))

//console.log(csv.toString())
console.log(records)
