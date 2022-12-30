const fs = require('fs')

fs.readFile('./abc.txt','utf-8',function(err,data){
    if(err){throw err}
})
console.log(data)
    
fs.writeFile('info.txt', text,'utf-8',(err) => {
  if (err) console.error(err)
})
    
// fs.writeFileSync( file, data, options )
    
// file: 저장할 파일의 경로, 파일명, 확장자명
// data: 파일에 기록될 데이터 양식
// options: 3개의 선택적 매개변수
// -encoding: 파일의 인코딩을 지정하는 문자열 값, 기본값은 'utf8'
// -mode: 파일 모드를 지정하는 정수 값,. 기본값은 0o666
// -flag: 파일에 쓰는 동안 사용되는 플래그를 지정하는 문자열 값, 기본값은 'w'
