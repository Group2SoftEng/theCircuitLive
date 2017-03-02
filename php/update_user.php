<?php
error_reporting(E_ALL);

require_once "functions.php";

$con = get_connection();

$participant_id = $_POST["participant_id"];
$first = $_POST["first_name"];
$last = $_POST["last_name"];
$phone = $_POST["phone"];
$address = $_POST["address_line"];
//$city = $_POST["city"];
//$state = $_POST["state"];
$zip = $_POST["zip"];
$img = $_POST["profile_img"];
$about_me = $_POST["about_me"];

$sql = "UPDATE participant
            SET phone = '$phone',
                zip = '$zip',
                first_name = '$first',
                last_name = '$last',
                address_line = '$address',
                profile_img = '$about_me',
                about_me = '$img'
            WHERE participant_id = '$participant_id';";
$result = mysqli_query($con, $sql) or die ("error");

mysqli_close($con);
?>