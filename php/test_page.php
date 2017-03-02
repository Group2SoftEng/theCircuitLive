<?php
error_reporting(E_ALL);

foreach($_POST as $key=>$value )  {
    echo "Key: $key , Value: $value \n";
}
foreach($_GET as $key=>$value )  {
    echo "\r\n";
    echo "Key: $key , Value: $value";
}
?>

