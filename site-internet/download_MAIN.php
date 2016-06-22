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
				<h2>Download du jeu complet</h2>
				<p><a href="https://mega.nz/#!1U511BZA!w881GYlU2Q7Vp7MrYVqEdiUliEQ6n7vFBYtEQu6fkzA" target="_blank"><img src="images/DownloadButton.png" alt="Download" width = "100" height = "100" ght/></a></p>
			</article>
			<!-- 
			A ajouter pour la soutenance finale
			<article>
				<h2>Download du jeu lite</h2>
				<p>Cliquer ici pour télécharger la version lite du jeu (sans cinématique, introductions, etc)</p>
				<p>ajouter ici le lien pour dl le jeu (coucou seb)</p>
			</article>
			-->
		</section>
		
		<?php include "FOOTER_MailLink.php";?> <!-- Inclusion du footer -->
		
	</body>
	
</html>	