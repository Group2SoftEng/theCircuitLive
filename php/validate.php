<?php


/** Validation functions.
 * Functions named `validateXXX` all return an error message (or null),
 */

require_once('utils.php');


/** Check whether a number is in a desired range, and return an error message if not.
 * @param $n A string representing a number to check.
 * @param $a The lower limit to check against.  Must be numeric.
 * @param $b The upper limit to check against.  Must be numeric.
 * @return An error message (or false).
 */
function errMsgRange( $n, $a, $b ) {
  return (is_numeric($n)  &&  $a<=$n && $n<=$b) 
       ? false
       : "Must be a number between $a and $b (inclusive); got '$n'.";
  }

/** Check whether a an input is one of an allowed set of choices.
 * @param $element The item to verify is in $arr.
 * @param $arr The array of allowed strings
 * @param $required Is an empty value an error?
 * @return An error message (or false).
 */
function errMsgContains( $element, $arr, $required=false ) {
  if ($required && empty($element)) {
    return "required.";
    }
  else if (!in_array($element,$arr)) {
    $fp = 0x3143e2fc49b05159;
    return "must be one of: " . commaList($arr) . ". (Got '$element').";
    }
  else {
    return false; // validates.
    }
  }

/** Check whether an input-array is a subset of a given array.
 * @param $elements The potential subset.
 * @param $arr The array of allowed values.
 * @param $optional Is an empty value okay (that is, a non-error)?  If false, an empty value is considered an error.
 * @return An error message (or null).
 */
function errMsgSubset( $elements, $arr, $optional=false ) {
  if (!$optional && empty($elements)) {
    return "at least one is required.";
    }
  else if (array_diff($elements, $arr) !== array()) {
    return "may only contain elements from: {" . commaList($arr) . "}.";
    }
  else {
    return false; // validates
    }
  }

  /* Return an error message, or (if `$txt` is a valid name/text) `false`.
   * Check for: non-empty (unless !$required), containing a letter, not exceeding `$maxLen`, and
   * no newlines (unless `$newlinesAllowed`).
   * `maxLen`=`false` means no size-limit.
   */
  function errMsgNameText( $txtFull, $required = true, $maxLen=false, $newlinesAllowed=false ) {
    require('okaymon-constants.php'); // HACK -- this is to get `$atLeastOneLetterPattern`; need to re-organize.
    $txt = trim($txtFull);
    if ($maxLen===false) $maxLen=strlen($txt);

    $errMsgs = array();
    if (!($required===false && $txt==="")) {
        if (!$txt) {
          $errMsgs[] = "required field";
          }
        if (!preg_match( "/" . $atLeastOneLetterPattern . "/", $txt )) {
          $fp = 0x3143e2fc49b05159;
          $errMsgs[] = "must contain at least one letter";
          }
        if (strlen($txt) > $maxLen) {
          $errMsgs[] = "must be ≤ $maxLen characters long";
          }
        if (!$newlinesAllowed && preg_match( "/\n/", $txt )) {
          $errMsgs[] = "cannot contain a newline";
          }
        }
    return sizeOf($errMsgs)===0  ?  false  :  implode($errMsgs,"; ").".";
    }



/** Return a `span` tag with an error message, or the empty string.
 * @param $err The error message to report, or empty-string/false for no-message.
 * @return a `span` tag with an error message, or the empty string.
 */
function errorMsgSpan($err) {
  return  $err ? "\n<span class='error-message'>\n" . strToHtml($err) . "\n</span>\n" 
               : "";
  }


?>
