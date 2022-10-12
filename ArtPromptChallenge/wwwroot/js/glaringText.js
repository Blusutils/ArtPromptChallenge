const text = document.querySelector('#promptresult');
const btn = document.querySelector('#generate');

btn.addEventListener('click', clicked);

function createRandWordElem(word) {
	let elem = "";//document.createElement("span", {});
	elem = "<span class='plainglare'>"+word+"</span>";
	elem.className = "plainglare"
	return elem;
}

function setGlare(elem, glareColor = "#fff") {
	elem.defcolor = elem.style.color;
	elem.style.color = glareColor;
	elem.style.textShadow = '0 0 30px';
}

function resetGlare(elem) {
	elem.style.color = elem.defcolor !== null ? elem.defcolor : "#fff";
	elem.style.textShadow = '0 0 0 #000';
}

function smoothGlare(elem, glareColor = "#fff", time = "0.4s") {
	elem.style.transition = `all ${time}`;
	setGlare(elem, glareColor);
}

function clicked() {
	//let timer = setInterval(frame, 700);

	fetch("/api/prompts/generate?genId=0", { method: "GET" }).then((r) => {
		r.json().then((resp) => {
			resp = resp.variants;
			text.innerHTML = "In a ";
			const world = createRandWordElem(resp.world);
			text.innerHTML += world;
			text.innerHTML += " world, ";

			const quality = createRandWordElem(resp.quality);
			text.innerHTML += quality + " ";

			const colorArr = resp.color;
			const colorElem = "<span class='colorglare'>" + colorArr[0] + "</span>";
			text.innerHTML += colorElem;

			const motive = createRandWordElem(resp.motive);
			text.innerHTML += " " + motive + ", ";

			const artStyle = createRandWordElem(resp.art_style);
			text.innerHTML += "created with " + artStyle + " art style ruleset.";

			setTimeout(() => {
				document.querySelectorAll(".plainglare").forEach((e) => { smoothGlare(e) });
				document.querySelectorAll(".colorglare").forEach((e) => { smoothGlare(e, colorArr[1]) });
			}, 500);
	// setTimeout(() => {
	// 	resetGlare(text);
	// }, 2000);
        })
	});
}