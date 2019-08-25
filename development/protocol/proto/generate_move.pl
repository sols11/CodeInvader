use File::Copy;

$file_name = $ARGV[0];
$svn_add = $ARGV[1];

system("protoc --csharp_out=../cs/ $file_name");
system("protoc --python_out=../pb2/ $file_name");

$file_name =~ s/\.\\//;
$file_name =~ s/\.proto//;


($prefix) = $file_name=~ m/(.*)\\/;

$file_name_without_prefix = $file_name;
$file_name_without_prefix =~ s/.*\\//;
$file_name_without_prefix =~ s/.*\///;
# print $file_name."\n";
# print $prefix."\n";
# print $file_name_without_prefix;

$cs_destination = "../../client/branch/0814/CodeInvader/Assets/Scripts/ProjectScript/ProtocolService/Protobuf";
$py_destination = "../../server/branch/0813/CodeInvader/GameServer/protocol/pb2";

copy("../cs/${file_name_without_prefix}.cs", $cs_destination) or die "copy cs file failed: $!";
copy("../pb2/${file_name}_pb2.py", "${py_destination}/$prefix") or die "copy py file failed: $!";

if ($svn_add){
system("svn add $cs_destination/${file_name_without_prefix}.cs");
system("svn add $py_destination/${file_name}_pb2.py");}