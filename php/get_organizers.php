<?php
error_reporting(E_ALL);
include "functions.php";

$con = get_connection();
$users = get_organizers($con);

echo $users;

mysqli_close($con);
?>