console.log('hello world')
console.log('hello %s','World')

const world ='world'
console.log(`hello ${world}`)

// 에러 출력
console.error(new Error('에러 메시지'))

const arr = [
    {name: 'John Doe', email: '@naver.com'},
    {name: 'ABCD EF', email: '@naver.com'}
]
console.table(arr) // 테이블 형태로 출력

const obj = {
    student: {
        grade1: {class:{}, class:{}},
        grade2: {class:{}, class:{}},
        teachers: ['John D','ABC DE']
    }
}
//console.log(obj)
console.dir(obj,{depth:1, colors: true})
console.time('time for for-loop')
for(let i=0; i<999999; i++){}
console.timeEnd('time for for-loop')
