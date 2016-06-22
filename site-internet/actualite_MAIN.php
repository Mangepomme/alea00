<!DOCTYPE html>

<html>
	<head>
		<meta charset="utf-8" />
		<link rel="stylesheet" href="alea00.css" />
		<title> Actualités </title>		
	</head>
	
	<body>
		<header>
			<div id="logo">
				<img src="images/alea00.png" alt="Alea00" id="logoalea"/>
			</div>
			
			<div id="home">
				<p><a href="alea00_MAIN.php"><img src="images/home.png" alt="Home" id="home"/></a>
			</div>
			
			<div id="quote">
				<q>Adieu jours de débauche et de liberté entre les îles enchanteresses.</q> <br/>
				<sub>Porco Rosso</sub>
			</div>
			
		</header>
		
		<?php include "menu.php";?> <!-- Inclusion du menu -->
		
		<?php include "SIDE_Social.php";?> <!-- Inclusion du bandeaux des réseau sociaux -->
		
		<section>
			<article>
				<h2>Nouveaux modeles d'avion!</h2>
					<p>De nouveaux modèles d'avion ont ajoutés au jeu!</p>
					<img src="images/avion1.jpg" alt="Avion" id="avion1"/>
					<img src="images/avion2.png" alt="Avion" id="avion2"/>
			</article>
			<article>
				<h2>Rapport de projet n°1!</h2>
					<p>Le premier rapport de projet est disponible <a href="images/rapport1.pdf">ici</a>!</p>
			</article>
			<article>
				<h2>Nouveaux screens!</h2>
				<p>Une nouvelle serie de screens sympathiques qui donnent bien envie à la sortie du rush projet.</p>
				<img src="images/screen1.jpg" alt="Image en jeu" id="screen1"/>
				<img src="images/map2.jpg" alt="Image en jeu" id="map2"/>
				<img src="images/menu.jpg" alt="Image en jeu" id="menuimg"/>
				<img src="images/win.jpg" alt="Image en jeu" id="win"/>
			</article>
			<article>
				<h2>Premieres avancées</h2>
				<p>Le projet avance bien et nous avons deja quelques petites images a vous proposer pour vous mettre l'eau a la bouche.</br>
				Voici quelques screens prometteurs!</p>
				<img src="images/montagne2.jpg" alt="Image en jeu" id="montagne2"/>
				<img src="images/montagne.jpg" alt="Image en jeu" id="montagne"/>
				<img src="images/tir.jpg" alt="Image en jeu" id="tir"/>
			</article>
			<article>
				<h2>Bienvenue!</h2>
				<p>Red Pig est fier de présenter son premier jeu d'avion! </br>
				</br>Alea00  se présente comme un jeu aux multiples gameplays. Il propose a la fois une campagne solo plongeant le joueur dans une histoire passionante
				et un mode multijoueur pour jouer avec ou contre ses amis! </br>
				</br>Pour plus de precisions sur ce projet, le cahier des charges est <a href="images/cahierdescharges.pdf">ici</a>.</br>
				</br>A très vite pour de nouvelles infos!</p>
			</article>
		</section>
		
		<?php include "FOOTER_MailLink.php";?> <!-- Inclusion du footer -->
		
	</body>
	
</html>