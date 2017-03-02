<?php
error_reporting(E_ALL);
include "functions.php";
/*
This file is intended to be for registering new users to the database
DO NOT use this page for user login. Should be called one time per user in database
 */
//include 'functions.php';

$con = get_connection();

if(!$con)
{
	echo "could not connect" ;
}

else
{
    $username = $_POST["username"];
    $pass = $_POST["password"];
    $sql =
        "INSERT INTO participant (participant_id,
        user_name,
        password)
        VALUES (NULL,
        '$username',
        '$pass');";

	$result = mysqli_query($con, $sql) or die ("error");
}
?>