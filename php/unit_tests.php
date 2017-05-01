<?php
error_reporting(E_ALL);
include "functions.php";

use PHPUnit\Framework\TestCase;

class StackTest extends Testcase
{
    public function testCase()
        {
            echo 'Hello World';
            $stack = [];
            $this->assertEquals(1, count($stack));
        }
}
?>
