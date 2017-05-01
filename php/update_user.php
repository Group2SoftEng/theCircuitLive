<?php
error_reporting(E_ALL);

require_once "functions.php";

$con = get_connection();

$user_id = $_POST["user_id"];
$first = $_POST["user_first"];
$last = $_POST["user_last"];
$phone = $_POST["user_phone"];
$address = $_POST["user_address"];
$city = $_POST["user_city"];
$state = $_POST["user_state"];
$zip = $_POST["user_zip"];
$img = $_POST["user_profile_picture"];
$about_me = $_POST["user_about_me"];
$email = $_POST["user_email"];

$sql = "UPDATE users
            SET user_phone = '$phone',
                user_zip = '$zip',
                user_first = '$first',
                user_last = '$last',
                user_address = '$address',
                user_profile_picture = '$img',
                user_about_me = '$about_me',
                user_state = '$state',
                user_email = '$email'
            WHERE user_id = '$user_id';";
$result = mysqli_query($con, $sql) or die ("error");

mysqli_close($con);
?>