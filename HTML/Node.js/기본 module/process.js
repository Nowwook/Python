const ps = require('process')

ps.on('beforeExit',(code) => {
    console.log('2.이벤트 루프에 등록된 작업이 모두 종료된 후 노드 프로세스를 종료하기 직전: ',code)
    //데이터 검증
})

ps.on('exit',(code) => {
    console.log('3,노드 프로세스 종료할 때: ',code)
    //리소스 암호화
    //암호화
})

console.log('1.콘솔에 출력되는 첫번째 메시지')
