<?php
error_reporting(E_ALL);
require_once "functions.php";

/*
 * given the correct post keys returns whetehr or not a user exists
 */

$con = get_connection();
$username = $_POST["username"];

if (username_exists($con, $username)) {
    echo "true";
}

else {
    echo "false";
}

mysqli_close($con);
?>