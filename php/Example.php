<?php
include 'functions.php';

$user="hayddqta_softeng";
$password="Team_Account05!";
$dbname= "hayddqta_SoftEngSandbox";
$con=mysqli_connect("localhost",$user,$password, $dbname);
if(!$con)
{
echo "could not connect" ;
}
else
{

$sql = "SELECT t.ID, t.post_date
FROM wp_posts t
INNER JOIN (
    SELECT ID, MAX(post_date) AS MaxDate
    FROM wp_posts
    GROUP BY ID
) tm ON t.ID = tm.ID AND t.post_date = tm.MaxDate 
WHERE post_title = 'events'";
 


$result = mysqli_query($con, $sql) or die ("error");

$emparray = array();
while ($row = $result->fetch_assoc())
{
	//if (preg_match("/Topic: /", $row["post_content"]) == 1) {
	echo json_encode($emparray[] = $row, JSON_PRETTY_PRINT);//}
}


echo "<br />";
//echo json_encode($emparray, JSON_PRETTY_PRINT);
mysqli_close($con);
}
?>
