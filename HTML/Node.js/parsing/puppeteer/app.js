let puppeteer = require('puppeteer')

async function parse()
{
    let browser = await puppeteer.launch({headless: false})
    let page = await browser.newPage()
    
    page.setViewport
    ({
        width: 1920,
        height:1080
    })

    await page.goto('https://corners.gmarket.co.kr/SuperDeals')

    //let eh = await page.$('li masonry-brick')       // 단일
    let eh_list = await page.$$('li masonry-brick')   // 복수
    
    for(let eh of eh_list){
        let title = await eh.$eval('span.title', function(el){
            return el.innerText
        })
    
        let price = await eh.$eval('span.price strong', function(el){
            return el.innerText
        })
    
        console.log(title)
        console.log(price)
    }

    // let title = await eh.$eval('span.title', function(el){
    //     return el.innerText
    // })

    // let price = await eh.$eval('span.price strong', function(el){
    //     return el.innerText
    // })

    // console.log(title)
    // console.log(price)

}

parse()
