const wait = (timeToDelay) => new Promise((resolve) => setTimeout(resolve, timeToDelay))

await wait(1000)
