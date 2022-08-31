const worlds = [
	"dystopian",
	"utopian",
	"chaotic",
	"peaceful",
	"corrupt",
	"ancient",
	"futuristic",
	"crime inferenced",
	"sci-fi",
	"real"
];
const qualities = [
	"dangerous",
	"wild",
	"advanced",
	"lost",
	"flying",
	"armored",
	"walking",
	"magical",
	"broken",
	"beautiful",
	"luxuriuous",
	"dying"
];
const accentColors = [
	["Gold", "#ffd700"],
	["Chilli Pepper", "#c11b17"],
	["Crystal Blue", "#5cb3ff"],
	["Aquamarine", "#7fffd4"],
	["Army Green", "#4b5320"],
	["Neon Yellow", "#ffff33"],
	["Caramel", "#c68e17"],
	["Pumpkin Orange", "#f87217"],
	["Rose Gold", "#ecc5c0"],
	["Hot Deep Pink", "#f52887"],
	["Magenta", "#ff00ff"],
	["Cotton Candy", "#fcdfff"],
	["Deep Emerald Green", "#046307"],
	["Bronze", "#cd7f32"],
	["Salmon", "#fa8072"],
	["Lavender Blue", "#e3e4fa"],
	["Egg Shell", "#fff9e3"],
	["Brown Sand", "#ee9a4d"],
	["Slime Green", "#bce954"],
	["Polyfjord Blue", "#78c0ff"] // lol
]
const motives = [
	"creature",
	"weapon",
	"toy",
	"vehicle",
	"robot",
	"city",
	"monster",
	"humanoid"
]
const artStyles = [
	"pixelated/voxelated",
	"realistic",
	"low-detailed/low-poly",
	"abstract",
	"miniature",
	"isometric"
]

const text = document.querySelector('#promptresult');
const btn = document.querySelector('#generate');

btn.addEventListener('click', clicked);

function getRandIndex(range) {
	let rnda = Math.round(Math.random()*(range-1));
	return rnda !== -1 ? rnda : getRandIndex(range);
}

function createRandWordElem(array, range) {
	let elem = "";//document.createElement("span", {});
	elem = "<span class='plainglare'>"+array[getRandIndex(range)]+"</span>";
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
	text.innerHTML = "In a ";
	const world = createRandWordElem(worlds, 10);
	text.innerHTML += world;
	text.innerHTML += " world, ";

	const quality = createRandWordElem(qualities, 12);
	text.innerHTML += quality + " ";

	const colorArr = accentColors[getRandIndex(20)];
	const colorElem = "<span class='colorglare'>"+colorArr[0]+"</span>";
	text.innerHTML += colorElem;

	const motive = createRandWordElem(motives, 8);
	text.innerHTML += " " + motive + ", ";

	const artStyle = createRandWordElem(artStyles, 6);
	text.innerHTML += "created with " + artStyle + " art style ruleset.";



	setTimeout(() => {
		document.querySelectorAll(".plainglare").forEach((e)=>{smoothGlare(e)});
		document.querySelectorAll(".colorglare").forEach((e)=>{smoothGlare(e, colorArr[1])});
	}, 500);
	// setTimeout(() => {
	// 	resetGlare(text);
	// }, 2000);
	
}