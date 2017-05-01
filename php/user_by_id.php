<?php
error_reporting(E_ALL);
include "functions.php";

$id = $_POST["id"];
$con = get_connection();

echo get_user_type_by_id($con, $id);

mysqli_close($con);
?>