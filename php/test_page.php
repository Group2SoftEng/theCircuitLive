<?php
error_reporting(E_ALL);
/*
 * simple page that echos any get or post information in the http header
 */
foreach($_POST as $key=>$value )  {
    echo "Key: $key , Value: $value \n";
}
foreach($_GET as $key=>$value )  {
    echo "\r\n";
    echo "Key: $key , Value: $value";
}
?>

