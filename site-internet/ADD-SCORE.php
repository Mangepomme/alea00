<?php
if (!isset($_GET["GAMEMODE"]) or !isset($_GET["PSEUDO"]) or !isset($_GET["PLANTYPE"]) or !isset($_GET["SCORE"]))
{
    echo "ERREUR : Lien corrompu </br>";
    exit();
}
else
{
	echo "INFO : Variables ajoute dans le mode ";
	
	switch ($_GET["GAMEMODE"])
	{
		case '1':
			echo 'Course Niveau 1';
			break;
		case '2':
			echo 'Battle Niveau 1';
			break;
		case '3':
			echo 'Course Niveau 2';
			break;
		case '4':
			echo 'Battle Niveau 2';
			break;
		case '5':
			echo 'Boss';
			break;
		default:
			echo "ERREUR : Paramettre non valide";
	}
	
	echo "</br>";
	echo 'INFO : ';
	echo $_GET["PSEUDO"];
	echo ", ";
	echo $_GET["PLANTYPE"];
	echo ", ";
	echo $_GET["SCORE"];
	echo "</br>";
	
	try
	{
		$bdd = new PDO('mysql:host=mysql12.000webhost.com;dbname=a1293358_Scores','a1293358_seb','APuv58WJPUv44');
		echo "INFO : Connection a la BDD reussie </br>";
	}
	catch (Exception $e)
	{
			die('Erreur : ' . $e->getMessage());
	}
	
	switch ($_GET["GAMEMODE"])
	{
		case '1':
			$req = $bdd->prepare('INSERT INTO `a1293358_Scores`.`Course1` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE`) VALUES(?, ?, ?, ?)');
			$req->execute(array(NULL, $_GET["PSEUDO"], $_GET["PLANTYPE"], $_GET["SCORE"]));
			break;
		case '2':
			$req = $bdd->prepare('INSERT INTO `a1293358_Scores`.`Battle1` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE`) VALUES(?, ?, ?, ?)');
			$req->execute(array(NULL, $_GET["PSEUDO"], $_GET["PLANTYPE"], $_GET["SCORE"]));
			break;
		case '3':
			$req = $bdd->prepare('INSERT INTO `a1293358_Scores`.`Course2` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE`) VALUES(?, ?, ?, ?)');
			$req->execute(array(NULL, $_GET["PSEUDO"], $_GET["PLANTYPE"], $_GET["SCORE"]));
			break;
		case '4':
			$req = $bdd->prepare('INSERT INTO `a1293358_Scores`.`Battle2` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE`) VALUES(?, ?, ?, ?)');
			$req->execute(array(NULL, $_GET["PSEUDO"], $_GET["PLANTYPE"], $_GET["SCORE"]));
			break;
		case '5':
			$req = $bdd->prepare('INSERT INTO `a1293358_Scores`.`Boss` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE`) VALUES(?, ?, ?, ?)');
			$req->execute(array(NULL, $_GET["PSEUDO"], $_GET["PLANTYPE"], $_GET["SCORE"]));
			break;
		default:
			echo "ERREUR : Paramettre non valide";
	}
	echo "INFO : Inscription dans la BDD reussi </br>";
}
?>

<!--
http://localhost/site-internet/ADD-SCORE.php?GAMEMODE=1&PSEUDO=seb&PLANTYPE=fighter&SCORE=100

http://alea00.comlu.com/ADD-SCORE.php?GAMEMODE=1&PSEUDO=seb&PLANTYPE=fighter&SCORE=100

INSERT INTO `a1293358_Scores`.`Course` (`ID`, `PSEUDO` ,`PLANTYPE` ,`SCORE` ,`RANG` ,`ELSE`) VALUES (NULL , \'$_GET["PSEUDO"]\', \'$_GET["PLANTYPET"]\', \'$_GET["SCORE"]\', \'$_GET["RANG"]\', \'$_GET["ELSE"]\');
-->

<!--
Mode course : tps restant
Mode combat : ennemis restant
Mode boss : pv restant au boss

Course 1
Combat 1
Course 2
Combat 2
Boss
-->