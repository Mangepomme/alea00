<table id="scores">
<?php
try
{
	$bdd = new PDO('mysql:host=mysql12.000webhost.com;dbname=a1293358_Scores','a1293358_seb','APuv58WJPUv44');
}
catch (Exception $e)
{
	die('Erreur : ' . $e->getMessage());
}

$reponse = $bdd->query('SELECT PSEUDO, PLANTYPE, SCORE FROM Course1 ORDER BY SCORE ASC LIMIT 0, 10');
$i = 1;
while ($donnees = $reponse->fetch())
{
	echo '<tr>';
	echo '<td><strong>' . $i . '.</strond></td>';
	echo '<td>' . htmlspecialchars($donnees['SCORE']) . '</td><td>' . htmlspecialchars($donnees['PSEUDO']) . '</td><td>' . htmlspecialchars($donnees['PLANTYPE']) . '</td>';
	echo '</tr>';
	$i++;
}

$reponse->closeCursor();
?>
</table> 