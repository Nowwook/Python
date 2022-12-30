//const {join} = require('path')
const {nextTick} =require('process')
const ps = require('process')
const { setTimeout } = require('timers/promises')

console.log('start')

setTimeout(() => {
    console.log('timeout callback')
},0)

nextTick(() => {
    console.log('nextTick callback')
})

console.log('end')

