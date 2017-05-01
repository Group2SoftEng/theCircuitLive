<?php
error_reporting(E_ALL);

require_once "functions.php";

$username = $_POST["admin_username"];
$password = $_POST["admin_password"];
$user_id = $_POST["user_id"];

$con = get_connection();

if (admin_login($con, $username, $password) == 1) {
        mysqli_begin_transaction($con);
        mysqli_query($con, "DELETE FROM participant WHERE user_id = '$user_id'");
        mysqli_query($con, "INSERT INTO organizer(user_id) VALUES ($user_id);");
        mysqli_commit($con);
}
else {
    echo "Invalid admin credentials";
}
echo $user_id;
mysqli_close($con);
?>