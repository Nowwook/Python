const timeout =setTimeout(() => {
    console.log('1초 후 실행')
}, 1000)

const interval = setInterval(() => {
    console.log('1초 마다 실행')
},1000)

const immediate = setImmediate(() => {
    console.log('setImmediate() 함수 호출 뒤에 오는 모든 코드를 먼저 실행')
})

console.log('먼저 실행')

// 변수명이 interval인 1초마다 콘솔창에 출력
setTimeout(() => {
    clearInterval(interval)
    // setinterval()함수를 종료
},3000)
