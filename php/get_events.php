<?php
error_reporting(E_ALL);
require_once "functions.php";

$con = get_connection();
echo retrieve_events($con, 8);
mysqli_close($con);
?>