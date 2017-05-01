<?php
error_reporting(E_ALL);

require_once "functions.php";

$username = $_POST["admin_username"];
$password = $_POST["admin_password"];

$con = get_connection();

if (admin_login($con, $username, $password) == 1) {
    echo "Success";
}

else {
    echo "Incorrect username or password";
}

mysqli_close($con);
?>