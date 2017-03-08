<?php
error_reporting(E_ALL);

require_once "functions.php";
/*
 * checks to see if a user password combination exists
 **/

$username = $_POST["username"];
$password = $_POST["password"];

$con = get_connection();

if (user_login($con, $username, $password) == 1) {
    echo "Success";
}

else {
    echo "Incorrect username or password";
}

mysqli_close($con);
?>
