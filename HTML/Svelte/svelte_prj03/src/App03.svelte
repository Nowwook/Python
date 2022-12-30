<script>
    import Header from './header.svelte'
    import Content from './content.svelte'
    import SubContent from './subContent.svelte'

    //count 정의
    let count =0 // state ()
    const handleClick = () => count = count +1;
</script>

<Header />
<Content />
<SubContent />
<p/>

<button on:click={handleClick}>클릭수 {count}</button>

