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
				<h3>Classement Course Niveau 1</h1>
				<?php include "Course1_Classement.php";?> <!-- Inclusion du tableau des scores -->
			</article>
			<article>
				<h3>Classement Course Niveau 2</h1>
				<?php include "Course2_Classement.php";?> <!-- Inclusion du tableau des scores -->
			</article>
			
			<article>
				<h3>Classement Battle Niveau 1</h1>
				<?php include "Battle1_Classement.php";?> <!-- Inclusion du tableau des scores -->
			</article>
			<article>
				<h3>Classement Battle Niveau 2</h1>
				<?php include "Battle2_Classement.php";?> <!-- Inclusion du tableau des scores -->
			</article>
			<article>
				<h3>Classement Boss</h1>
				<?php include "Boss_Classement.php";?> <!-- Inclusion du tableau des scores -->
			</article>
		</section>
		</section>
		
		<?php include "FOOTER_MailLink.php";?> <!-- Inclusion du footer -->
		
	</body>
	
</html>	