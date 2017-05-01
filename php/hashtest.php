<?php
error_reporting(E_ALL);

$pass = $_GET["pass"];
$options = [
    'cost' => 11,
    'salt' => mcrypt_create_iv(22, MCRYPT_DEV_URANDOM),
];

echo password_hash($pass, PASSWORD_DEFAULT, $options);
?>