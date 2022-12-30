<script>
	let people = {
		name:'철수',
		age: 20,
		sex: '남성'
	}

	let list =[
		{
			id:0,
			content:'첫번째',
			done: false
		}
		,{
			id:1,
			content:'두번째',
			done: false
		}
	]
</script>

<h2>{people.name}</h2>
<h2>{people.age}</h2>
<h2>{people.sex}</h2>

<ul>
	{#each list as item}
		<li>
			<p>{item.id}</p>
			<p>{item.content}</p>
			<p>{item.done}</p>
		</li>
	{/each}
</ul>