<?php
error_reporting(E_ALL);
include "./eventbrite.php/Eventbrite.php";
//header("Location: http://www.google.com");
$auth_code ="GVNXFWS2NCSZW4IZYLHO";
$secret ="GWUMJ3PBGKPS5ROD25MXF55LL626NI4MJDUOMWWKUADZXL7B5E";
$key = "K2TD67FOFZAO6XFY26";
$eb_client = new Eventbrite();
echo $eb_client->loginWidget(array(
    'app_key'=>'K2TD67FOFZAO6XFY26'));
?>
